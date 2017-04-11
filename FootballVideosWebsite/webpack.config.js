const path = require('path');
const webpackMerge = require('webpack-merge');
const commonPartial = require('./config/webpack.common');
const clientPartial = require('./config/webpack.client');
const serverPartial = require('./config/webpack.server');
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
    const serverConfig = webpackMerge({}, commonPartial, serverPartial);

    let clientConfig;
        
    const isProductionBuild = process.argv.indexOf('--env.prod') >= 0; 
    if (isProductionBuild) {
        clientConfig = webpackMerge({}, commonPartial, prodPartial);
    }
    else {
        clientConfig = webpackMerge({}, commonPartial, clientPartial);
    }

    const configs = [clientConfig, serverConfig];
    
    return configs;
}
