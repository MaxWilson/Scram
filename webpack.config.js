var path = require("path");
var webpack = require("webpack");

var cfg = {
  entry: {
    main:"./js/main.js"
  },
  output: {
    filename: "[name].bundle.js"
  },
  plugins: [
    new webpack.DefinePlugin({
      'process.env': {
        'NODE_ENV': JSON.stringify('production')
      }
    })
  ],
  module: {
    rules: [
      {
        enforce: 'pre',
        test: /\.js$/,
        exclude: /node_modules/,
        loader: 'source-map-loader'
      },
      {
        enforce: 'pre',
        test: /\.css/, 
        loader: 'style-loader!css-loader'
      }
    ]
  }
};

module.exports = cfg;