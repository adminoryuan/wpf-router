# wpf-router
- 开发计划
- [x] 基础功能实现
- [x] 前缀树路由
- [ ] 路由守卫
- [ ] 多级路由
- [ ] 增加路由元信息
- [ ] 计划中..

wpf 路由导航框架

# 使用示例
``` c#

  public partial class App : Application
    {
        private IWpfRouter router = WpfRouter.Instance;

        protected override void OnStartup(StartupEventArgs e)
        {
            var routers = RouterItem.builder()
                    .WithUrl("/home")
                    .WithComponent(new WindowComponent(typeof(MainWindow)))
                    .WithChildren(
                        RouterItem.builder()
                            .WithUrl("page1")
                            .WithComponent(new PageComponents(typeof(Page1)))
                            .Build(),
                        RouterItem.builder()
                            .WithUrl("page2")
                            .WithComponent(new PageComponents(typeof(Page3)))
            .Build()
                    ).Build();
            router.InitRouter(routers);
            router.NavicatTo("/home/page2");
        }
    }


   public partial class MainViewModel
    {
        private IWpfRouter router = WpfRouter.Instance;
        [RelayCommand]
        public void AddClick()
        {
            router.NavicatTo("/home/page1");
        }
    }

  <Grid>
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="2*"></ColumnDefinition>
            <ColumnDefinition Width="8*"></ColumnDefinition>
        </Grid.ColumnDefinitions>
        <Button Content="切换" Grid.Row="0" Command="{Binding AddClickCommand}"></Button>
       
        <StackPanel Grid.Column="1">
            <Frame x:Name="wpf_router_view_fream" Content=""></Frame>
            <local1:RouterView></local1:RouterView>
        </StackPanel>
    </Grid>

```
