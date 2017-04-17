const path = require('path');
const webpackMerge = require('webpack-merge');
const commonConfig = require('./webpack.common');
const webpackMergeDll = webpackMerge.strategy({ plugins: 'replace' });
const DllBundlesPlugin = require('webpack-dll-bundles-plugin').DllBundlesPlugin;
const AddAssetHtmlPlugin = require('add-asset-html-webpack-plugin');
const thirdParty = require('./third-party');
const helpers = require('./helpers');

module.exports = {
    devtool: 'cheap-module-source-map',
    output: {
        filename: '[name].js',
    },
    plugins: [
        new DllBundlesPlugin({
            bundles: {
                polyfills: thirdParty.polyfills,
                vendor: thirdParty.vendor
            },
            dllDir: path.join(__dirname, '../wwwroot', '/dist'),
            webpackConfig: webpackMergeDll(commonConfig, {
                devtool: 'cheap-module-source-map',
                plugins: []
            })
        }),
        /**
         * Plugin: AddAssetHtmlPlugin
         * Description: Adds the given JS or CSS file to the files
         * Webpack knows about, and put it into the list of assets
         * html-webpack-plugin injects into the generated html.
         *
         * See: https://github.com/SimenB/add-asset-html-webpack-plugin
         */
        new AddAssetHtmlPlugin([
            { filepath: helpers.root(`wwwroot/dist/${DllBundlesPlugin.resolveFile('polyfills')}`) },
            { filepath: helpers.root(`wwwroot/dist/${DllBundlesPlugin.resolveFile('vendor')}`) }
        ]),

    ]
};
