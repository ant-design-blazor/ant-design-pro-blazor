
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
dotnet new -i AntDesign.Templates::0.1.0-*
```

### Uninstall Template
```bash
dotnet new -u AntDesign.Templates
```

### Create New Project
```bash
# Create an empty wasm project
dotnet new antdesign --host=wasm

# Create wasm project with full pages
dotnet new antdesign --host=wasm --full

# Create an empty server-side project
dotnet new antdesign --host=server

# Create server-side project with full pages
dotnet new antdesign --host=server --full

# Create an empty hosted project
dotnet new antdesign --host=hosted

# Create hosted project with full pages
dotnet new antdesign --host=hosted --full
```

### Override Existing Project
```bash
## You can override an existing project with the --force
dotnet new antdesign --host=wasm --force
```