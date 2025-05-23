namespace ListViewMultiple.Presentation;

public partial record MainModel
{
    private INavigator _navigator;

    public MainModel(
        IOptions<AppConfig> appInfo,
        INavigator navigator)
    {
        _navigator = navigator;
        Title = "Main";
        Title += $" - {appInfo?.Value?.Environment}";
    }

    public string? Title { get; }

    public IState<string> Name => State<string>.Value(this, () => string.Empty);

    public IListFeed<string> Items =>
       ListFeed.Async<string>(static (ct) =>
       {
           var result = new List<string>
           {
            "Item 1",
            "Item 2",
            "Item 3",
            "Item 4",
            "Item 5",
            "Item 6",
            "Item 7",
            "Item 8",
            "Item 9",
            "Item 10"
           }.ToImmutableList();
           return ValueTask.FromResult(result);
       });

    public async Task GoToSecond()
    {
        var name = await Name;
        await _navigator.NavigateViewModelAsync<SecondModel>(this, data: new Entity(name!));
    }

}
