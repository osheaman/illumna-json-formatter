# json-formatter
illumna json formatter
* input: json file or url to json file of the structure: 
```
    [
      {
        "url": "https://…. Valid url", 
        "path":  "path_value_1", 
        "size": <integer size in bytes>
      }, ......
    ]
```
  * output json file of the form 
```  
    { 
      "path_value_1": {
        "url": "url value", 
        "size": <integer size>
        }, ...... 
    }
