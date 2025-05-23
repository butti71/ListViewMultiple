
Strange behavior when setting the ListView SelectionMode="Multiple" inside a FeedView.
When select multiple items and then unselect and select the first one, the second one is unselected also.

![Recording 2025-05-23 at 16 49 48](https://github.com/user-attachments/assets/4133f8c3-4a16-4d7a-b83a-30742ca967c9)


Project created with:

dotnet new unoapp -o ListViewMultiple -presentation "mvux" -config  -http "refit" -di  -nav "regions" -toolkit 

Model:
```
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
```
XAML:
```
      <mvux:FeedView Source="{Binding Items}"
                       utu:AutoLayout.PrimaryAlignment="Stretch">
          <DataTemplate>
            <UserControl>
              <Grid>
                <ListView Background="{ThemeResource SurfaceBrush}"
                          ItemsSource="{Binding Data}"
                          SelectionMode="Multiple"
                          IsItemClickEnabled="False"
                          Style="{StaticResource ListViewStyle}">
                  <ListView.ItemsPanel>
                    <ItemsPanelTemplate>
                      <ItemsStackPanel Orientation="Vertical"/>
                    </ItemsPanelTemplate>
                  </ListView.ItemsPanel>
                  <ListView.ItemTemplate>
                    <DataTemplate>
                      <TextBlock Foreground="{ThemeResource OnSurfaceBrush}"
                                 TextWrapping="Wrap"
                                 Text="{Binding}"
                                 Style="{StaticResource TitleMedium}"/>
                    </DataTemplate>
                  </ListView.ItemTemplate>
                </ListView>
              </Grid>
            </UserControl>
          </DataTemplate>
        </mvux:FeedView>
```