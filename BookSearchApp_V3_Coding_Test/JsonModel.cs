using Newtonsoft.Json;

namespace BookSearchApp_V3_Coding_Test
{
    public class JsonModel
    {
        [JsonProperty("numFound")] public long NumFound { get; set; }

        [JsonProperty("start")] public long Start { get; set; }

        [JsonProperty("numFoundExact")] public bool NumFoundExact { get; set; }

        [JsonProperty("docs")] public Doc[] Docs { get; set; }

        [JsonProperty("num_found")] public long WelcomeNumFound { get; set; }

        [JsonProperty("q")] public string Q { get; set; }

        [JsonProperty("offset")] public object Offset { get; set; }
    }

    public class Doc
    {
        [JsonProperty("key")] public string Key { get; set; }

        [JsonProperty("type")] public string Type { get; set; }

        [JsonProperty("seed")] public string[] Seed { get; set; }

        [JsonProperty("title")] public string Title { get; set; }

        [JsonProperty("title_suggest")] public string TitleSuggest { get; set; }

        [JsonProperty("edition_count")] public long EditionCount { get; set; }

        [JsonProperty("edition_key")] public string[] EditionKey { get; set; }

        [JsonProperty("publish_date")] public string[] PublishDate { get; set; }

        [JsonProperty("publish_year")] public long[] PublishYear { get; set; }

        [JsonProperty("first_publish_year")] public long FirstPublishYear { get; set; }

        [JsonProperty("isbn")] public string[] Isbn { get; set; }

        [JsonProperty("last_modified_i")] public long LastModifiedI { get; set; }

        [JsonProperty("ebook_count_i")] public long EbookCountI { get; set; }

        [JsonProperty("ebook_access")] public string EbookAccess { get; set; }

        [JsonProperty("has_fulltext")] public bool HasFulltext { get; set; }

        [JsonProperty("public_scan_b")] public bool PublicScanB { get; set; }

        [JsonProperty("publisher")] public string[] Publisher { get; set; }

        [JsonProperty("language")] public string[] Language { get; set; }

        [JsonProperty("author_key")] public string[] AuthorKey { get; set; }

        [JsonProperty("author_name")] public string[] AuthorName { get; set; }

        [JsonProperty("subject")] public string[] Subject { get; set; }

        [JsonProperty("publisher_facet")] public string[] PublisherFacet { get; set; }

        [JsonProperty("subject_facet")] public string[] SubjectFacet { get; set; }

        [JsonProperty("_version_")] public long Version { get; set; }

        [JsonProperty("author_facet")] public string[] AuthorFacet { get; set; }

        [JsonProperty("subject_key")] public string[] SubjectKey { get; set; }
    }
}