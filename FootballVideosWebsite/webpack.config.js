const path = require('path');
const webpackMerge = require('webpack-merge');
const commonPartial = require('./config/webpack.common');
const clientPartial = require('./config/webpack.client');
//const serverPartial = require('./webpack/webpack.server');
const prodPartial = require('./config/webpack.prod');

module.exports = function (options, webpackOptions) {
    options = options || {};
    webpackOptions = webpackOptions || {};

    //TODO: Add server config
    // const serverConfig = webpackMerge({}, commonPartial, serverPartial, {
    //     entry: options.aot ? './client/main.server.aot.ts' : serverPartial.entry, // Temporary
    //     plugins: [
    //         getAotPlugin('server', !!options.aot)
    //     ]
    // });

    let clientConfig;
        
    const isProductionBuild = process.argv.indexOf('--env.prod') >= 0; 
    if (isProductionBuild) {
        clientConfig = webpackMerge({}, commonPartial, prodPartial);
    }
    else {
        clientConfig = webpackMerge({}, commonPartial, clientPartial);
    }

    const configs = [];
    // if (!options.aot) {
    //     configs.push(clientConfig, serverConfig);
    // } else if (options.client) {
    //     configs.push(clientConfig);
    // } else if (options.server) {
    //     configs.push(serverConfig);
    // }
    //TODO: Add server config
    configs.push(clientConfig);
    return configs;
}
