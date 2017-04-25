const webpack = require('webpack');
const OptimizeJsPlugin = require('optimize-js-plugin');
const UglifyJsPlugin = require('webpack/lib/optimize/UglifyJsPlugin');
const BundleAnalyzerPlugin = require('webpack-bundle-analyzer').BundleAnalyzerPlugin;
const DllBundlesPlugin = require('webpack-dll-bundles-plugin').DllBundlesPlugin;
const webpackMerge = require('webpack-merge');
const webpackMergeDll = webpackMerge.strategy({ plugins: 'replace' });
const path = require('path');
const OptimizeCssAssetsPlugin = require('optimize-css-assets-webpack-plugin');
const AddAssetHtmlPlugin = require('add-asset-html-webpack-plugin');
const thirdParty = require('./third-party');
const commonConfig = require('./webpack.common');
const helpers = require('./helpers');

module.exports = {
    devtool: 'source-map',
    output: {
        sourceMapFilename: '[name].map',
        chunkFilename: '[id].[chunkhash].chunk.js'
    },
    plugins: [
        new DllBundlesPlugin({
            bundles: {
                vendor: thirdParty.polyfills.concat(thirdParty.vendor)
            },
            dllDir: path.join(__dirname, '../wwwroot', '/dist'),
            webpackConfig: webpackMergeDll(commonConfig, {
                devtool: 'source-map',
                plugins: [
                    new UglifyJsPlugin({
                        beautify: false,
                        sourceMap: true
                    })
                ]
            })
        }),
        new AddAssetHtmlPlugin([
            { filepath: helpers.root(`wwwroot/dist/${DllBundlesPlugin.resolveFile('vendor')}`) }
        ]),
        /**
     * Webpack plugin to optimize a JavaScript file for faster initial load
     * by wrapping eagerly-invoked functions.
     *
     * See: https://github.com/vigneshshanmugam/optimize-js-plugin
     */
        new OptimizeJsPlugin({
            sourceMap: false
        }),
        new BundleAnalyzerPlugin({
            // Can be `server`, `static` or `disabled`. 
            // In `server` mode analyzer will start HTTP server to show bundle report. 
            // In `static` mode single HTML file with bundle report will be generated. 
            // In `disabled` mode you can use this plugin to just generate Webpack Stats JSON file by setting `generateStatsFile` to `true`. 
            analyzerMode: 'static',
            // Port that will be used in `server` mode to start HTTP server. 
            // analyzerPort: 8888,
            // Path to bundle report file that will be generated in `static` mode. 
            // Relative to bundles output directory. 
            reportFilename: 'report.html',
            // Automatically open report in default browser 
            openAnalyzer: false,
            // If `true`, Webpack Stats JSON file will be generated in bundles output directory 
            generateStatsFile: false,
            // Name of Webpack Stats JSON file that will be generated if `generateStatsFile` is `true`. 
            // Relative to bundles output directory. 
            statsFilename: 'stats.json',
            // Options for `stats.toJson()` method. 
            // For example you can exclude sources of your modules from stats file with `source: false` option. 
            // See more options here: https://github.com/webpack/webpack/blob/webpack-1/lib/Stats.js#L21 
            statsOptions: null,
            // Log level. Can be 'info', 'warn', 'error' or 'silent'. 
            logLevel: 'info'
        }),
        new UglifyJsPlugin({
            beautify: false,
            sourceMap: true
        }),
        new OptimizeCssAssetsPlugin({
            assetNameRegExp: /\.css$/
        })
    ]
};
