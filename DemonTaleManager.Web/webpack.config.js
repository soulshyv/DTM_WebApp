const path = require("path");
var webpack = require("webpack");

module.exports = {
    entry: {
        // Output a "site.js" file from the "site.ts" file
        site: "./js/site.ts",
        // Output a "characters_create.js" file from the "create.ts" file
        characters: [ "./js/Characters/create.ts", "./js/Characters/details.ts"]

        // Output a "characters_details.js" file from the "details.ts" file
        //characters_details: "./js/Characters/details.ts"
    },
    // Make sure Webpack picks up the .ts files
    resolve: {
        extensions: [".ts"]
    },
    module: {
        rules: [
            {
                test: /\.tsx?$/,
                loader: "ts-loader",
                exclude: /node_modules/,
            }
        ]
    },
    plugins: [
        // Use a plugin which will move all common code into a "vendor" file
        //new config.optimization.splitChunks({
        //    name: "vendor"
        //})
    ],
    optimization: {
        splitChunks: {
            cacheGroups: {
                vendors: {
                    test: /[\\/]node_modules[\\/]/,
                    name: "vendors",
                    chunks: "all"
                }
            }
        }
    },
    output: {
        // The format for the outputted files
        filename: "[name].bundle.js",
        // Put the files in "wwwroot/js/"
        path: path.resolve(__dirname, "wwwroot/js/")
    }
};