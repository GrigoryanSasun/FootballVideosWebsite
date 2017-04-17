const path = require('path');
const helpers = require('./helpers');
const webpack = require('webpack');
const ContextReplacementPlugin = require('webpack/lib/ContextReplacementPlugin');
const CheckerPlugin = require('awesome-typescript-loader').CheckerPlugin;
const ngcWebpack = require('ngc-webpack');
const isDevBuild = process.argv.indexOf('--env.prod') < 0;

const HMR = helpers.hasProcessFlag('hot');
const AOT = helpers.hasNpmFlag('aot');

let commonConfig = {
    entry: {
        'main.browser': './Client/main.browser.ts'
    },
    output: {
        filename: '[name].js',
        path: path.join(__dirname, '../wwwroot', 'dist'),
        publicPath: '/dist/'
    },
    resolve: {
        /*
       * An array of extensions that should be used to resolve modules.
       *
       * See: http://webpack.github.io/docs/configuration.html#resolve-extensions
       */
        extensions: ['.ts', '.js', '.json', '.scss', '.css', '.html'],

        // An array of directory names to be resolved to the current directory
        modules: [helpers.root('Client'), 'node_modules'],
    },
    module: {
        rules: [
            //Pug support
            {
                test: /\.(pug|jade)$/,
                use: ['raw-loader', 'pug-html-loader']
            },
            {
                test: /\.ts$/, exclude: [/\.(spec|e2e)\.ts$/],
                use: [
                    {
                        loader: 'ng-router-loader',
                        options: {
                            loader: 'async-import',
                            genDir: 'compiled',
                            aot: AOT
                        }
                    },
                    'awesome-typescript-loader',
                    'angular2-template-loader'
                ]
            },
            { test: /\.html$/, use: 'html-loader' },
            { test: /\.json$/, use: 'json-loader' },
            { test: /\.(jpg|png|gif)$/, use: 'file-loader' },
            { test: /\.(woff|woff2|eot|ttf|svg)$/, use: 'file-loader' }
        ]
    },
    profile: true,
    plugins: [
        new webpack.DefinePlugin({
            'process.env': {
                'ENV': JSON.stringify(isDevBuild ? 'Development' : 'Production')
            }
        }),
        /*
       * Plugin: ForkCheckerPlugin
       * Description: Do type checking in a separate process, so webpack don't need to wait.
       *
       * See: https://github.com/s-panferov/awesome-typescript-loader#forkchecker-boolean-defaultfalse
       */
        new CheckerPlugin(),
        new ngcWebpack.NgcWebpackPlugin({
            disabled: !AOT,
            tsConfig: helpers.root('tsconfig.webpack.json')
        }),
        // new webpack.optimize.CommonsChunkPlugin({
        //     name: ['main', 'vendor', 'polyfills']
        // }),
        /**
         * Plugin: ContextReplacementPlugin
         * Description: Provides context to Angular's use of System.import
         *
         * See: https://webpack.github.io/docs/list-of-plugins.html#contextreplacementplugin
         * See: https://github.com/angular/angular/issues/11580
         */
        new ContextReplacementPlugin(
            // The (\\|\/) piece accounts for path separators in *nix and Windows
            /angular(\\|\/)core(\\|\/)src(\\|\/)linker/,
            helpers.root('Client'), // location of your Client
            {
                // your Angular Async Route paths relative to this root directory
            }
        ),

    ]
};

module.exports = commonConfig;