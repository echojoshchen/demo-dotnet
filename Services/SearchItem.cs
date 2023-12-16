namespace Demo.Search
{
    /// <summary>
    ///  Search index entry
    /// </summary>
    class SearchItem
    {
        public string lang { get; set; }
        public string contentFamily { get; set; }
        public string id { get; set; }
        public string preserved { get; set; }

        /// Search or filter fields.
        public string publishedDate { get; set; }
        public string title { get; set; }
        public string searchKeywords { get; set; }
        public string referenceCode { get; set; }
        public string textBlob { get; set; }
        public string category { get; set; }

        /// Calculated fields
        public string textSnippet { get; set; }

        public SearchItem()
        {
            lang = "";
            contentFamily = "";
            id = "";
            preserved = "";
            publishedDate = "";
            title = "";
            searchKeywords = "";
            referenceCode = "";
            textBlob = "";
            category = "";
            textSnippet = "";
        }

        public SearchItem(
            string lang,
            string contentFamily,
            string id,
            string preserved,
            string publishedDate,
            string title,
            string searchKeywords,
            string referenceCode,
            string textBlob,
            string category,
            string textSnippet
        )
        {
            this.lang = lang;
            this.contentFamily = contentFamily;
            this.id = id;
            this.preserved = preserved;
            this.publishedDate = publishedDate;
            this.title = title;
            this.searchKeywords = searchKeywords;
            this.referenceCode = referenceCode;
            this.textBlob = textBlob;
            this.category = category;
            this.textSnippet = textSnippet;
        }
    }
}
