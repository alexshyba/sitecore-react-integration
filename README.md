# Sitecore React integration (Powered by ReactJS.NET)

## How to get started.

1. Install clean Sitecore 8.1

2. Drop Sitecore.Kernel to `sc.lib` folder.

3. Modify the following two settings in `src/TdsGlobal.config` or add `src/TdsGlobal.config.user` with overrides under `<PropertyGroup Condition=" '$(Configuration)' == 'Debug' ">`:

`<SitecoreWebUrl>http://your-reactor/</SitecoreWebUrl>`

`<SitecoreDeployFolder>your-reactor-Sitecore-sandbox-path</SitecoreDeployFolder>`

4. Deploy in *Debug* configuration via TDS from VS.

## If you don't have TDS
1. Copy the `sitecore` folder from `src\Reactor.Items` to your `data\serialization\master` folder and update database. 
2. Deploy the output of the Web project with a script or manually.
3. Don't forget including the web.config. It contains much needed settings for ReactJS.NET to work.