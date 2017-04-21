const ExtractTextPlugin = require('extract-text-webpack-plugin');

const extractVendor = new ExtractTextPlugin('vendor.css');
const extractScss = new ExtractTextPlugin('custom.css');

module.exports = {
    module: {
        rules: [
            {
                test: /\.css$/, loaders: extractVendor.extract({
                    fallback: "style-loader",
                    use: ["css-loader"]
                })
            },
            {
                test: /\.scss$/, use: extractScss.extract({
                    fallback: "style-loader",
                    use: ['css-loader', 'sass-loader']
                })
            }

        ]
    },
    plugins: [
        extractVendor,
        extractScss,
    ]
};
