module.exports = {
  "/api":{
    target: process.env["services__mcptools__https_0"] || process.env["services__mcptools__https_0"],
    secure: process.env["NODE_ENV"] !== "development",
    pathRewrite : {
      "^/api": ""
    }
  }
}
