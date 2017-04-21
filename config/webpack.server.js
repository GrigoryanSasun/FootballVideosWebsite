const { root } = require('./helpers');

/**
 * This is a server config which should be merged on top of common config
 */
module.exports = {
    devtool: 'inline-source-map',
    module: {
        rules: [
            {
                test: /\.css$/, 
                use: ["css-loader"]
            },
            {
                test: /\.scss$/, 
                use: ['to-string-loader', 'css-loader', 'sass-loader']
            }
        ]
    },
    resolve: {
        extensions: ['.ts', '.js', '.json', '.css', '.scss'],
        // An array of directory names to be resolved to the current directory
        modules: [root('Client'), root('node_modules')],
    },
    entry: {
        'main-server': root('./Client/main.server.ts')
    },
    output: {
        libraryTarget: 'commonjs',
        path: root('./wwwroot/dist')
    },
    target: 'node'
};
