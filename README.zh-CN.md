[English](./README.md) | 简体中文 

<h1 align="center">Ant Design Pro Blazor</h1>

<div align="center">

开箱即用的中台前端/设计解决方案，Blazor 项目模板。

![](https://user-images.githubusercontent.com/8186664/44953195-581e3d80-aec4-11e8-8dcb-54b9db38ec11.png)

</div>

## 模板

```
- Dashboard
  - 分析页
  - 监控页
  - 工作台
- 表单页
  - 基础表单页
  - 分步表单页
  - 高级表单页
- 列表页
  - 查询表格
  - 标准列表
  - 卡片列表
  - 搜索列表（项目/应用/文章）
- 详情页
  - 基础详情页
  - 高级详情页
- 用户
  - 用户中心页
  - 用户设置页
- 结果
  - 成功页
  - 失败页
- 异常
  - 403 无权限
  - 404 找不到
  - 500 服务器出错
- 帐户
  - 登录
  - 注册
  - 注册成功
```

## 使用

### 安装模板
```bash
dotnet new -i AntDesign.Templates
```

### 如果已安装过，请先卸载模板
```bash
dotnet new -u AntDesign.Templates
```

### 模板的参数

| 参数              | 说明                                             | 类型                           | 默认值 |
| ----------------- | ------------------------------------------------ | ------------------------------ | ------ |
| `--full`          | 如果设置这个参数，会生成所有 Ant Design Pro 页面   | bool                           | false  |
| `--host`          | 指定托管模型                                     | `wasm` \| `server` \| `hosted` | `wasm` |
| `--styles`        | 指定样式构建类型                                 |  `css` \| `less`                | `css` |
| `--no-restore`    | 如果设置这个参数，就不会自动恢复包引用             | bool                           | false  |


### 覆盖项目
```bash
## You can override an existing project with the --force
dotnet new antdesign --host wasm --force
```