# Simple REST API
This is example project of making API with ASP.NET Core

# API interaction

>[!TIP]
>:heavy_check_mark: - provided query is free to use
>:warning: - query in developement and not fully tested
>:x: - query is not implemented or don't work properly

## List of queries for unauthorized access

- :x:```/Puzzles/result/search={search_parameter}&page={page}&category={category_id}``` - return list of puzzles by search query
- :heavy_check_mark:```/Puzzles/{id}``` - return Puzzle with given ```id```
- :x:```/Brands/result/search={search_parameter}&page={page}``` - return brands by search parameters
- :x:```/Brands/{id}``` - return brand by ```id```
- :x:```/Brands/{brand_id}/owned/search={search_parameter}&page={page}&category={category_id}``` - return list of puzzles by search query that owned by brand with given ```brand_id```


