
English | [简体中文](./README.zh-CN.md)

<h1 align="center">Ant Design Pro Blazor</h1>

<div align="center">

An out-of-box UI solution for enterprise applications as a Blazor boilerplate.

![](https://user-images.githubusercontent.com/8186664/44953195-581e3d80-aec4-11e8-8dcb-54b9db38ec11.png)

</div>

## Templates

```
- Dashboard
  - Analytic
  - Monitor
  - Workspace
- Form
  - Basic Form
  - Step Form
  - Advanced From
- List
  - Standard Table
  - Standard List
  - Card List
  - Search List (Project/Applications/Article)
- Profile
  - Simple Profile
  - Advanced Profile
- Account
  - Account Center
  - Account Settings
- Result
  - Success
  - Failed
- Exception
  - 403
  - 404
  - 500
- User
  - Login
  - Register
  - Register Result
```

## Usage

### Install Template

```bash
dotnet new -i AntDesign.Templates
```

### Uninstall template (If you have installed it)

```bash
dotnet new -u AntDesign.Templates
```

### Options for the template

| Options           | Description                                                        | Type                           | Default |
| ----------------- | ------------------------------------------------------------------ | ------------------------------ | ------- |
| `--full`          | If specified, generates all pages of Ant Design Pro                | bool                           | false   |
| `--host`          | Specify the hosting model                                          | `webapp` \| `wasm` \| `server` | `webapp` |
| `--styles`        | Whether use NodeJS and Less to compile your custom themes.         | `css` \| `less`                | `css`   |
| `--no-restore`    | If specified, skips the automatic restore of the project on create | bool                           | false   |

### Override Existing Project
```bash
## You can override an existing project with the --force
dotnet new antdesign --host webapp --force
```
