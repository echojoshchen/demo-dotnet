using System;

public enum SearchConfigErrorType
{
    invalidDirectory,
    dbError
}

public enum SearchLibraryErrorType
{
    invalidNativeCall,
    jseException
}

public class SearchConfigError : Exception {
    public SearchConfigErrorType type;

    public SearchConfigError(SearchConfigErrorType type, string message) : base(message) {
        this.type = type;
    }
}

public class SearchLibraryError : Exception {
    public SearchLibraryErrorType type;

    public SearchLibraryError(SearchLibraryErrorType type, string message) : base(message) {
        this.type = type;
    }
}
