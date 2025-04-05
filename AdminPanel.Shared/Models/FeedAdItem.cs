namespace AdminPanel.Shared.Models;

public class FeedAdItem
{
    public string AccentColour { get; set; } = "#cccccc";
    public string ButtonBackground { get; set; } = "#000000";
    public string ButtonBorder { get; set; } = "#ffffff";
    public string ButtonText { get; set; } = "";
    public DynamicSettings DynamicSettings { get; set; }
    public int? ContainerId { get; set; }
    public List<int> FeedIds { get; set; }
    public int Id { get; set; }
    public int ItemCount { get; set; }
    public string LandingPage { get; set; }
    public string Name { get; set; }
    public bool OnlyThisProfileProducts { get; set; }
    public int ProfileId { get; set; }
    public string State { get; set; } = "Active";
    public StaticRules StaticRules { get; set; }
    public int TemplateId { get; set; } = 235;
}

public class DynamicSettings
{
    public List<CustomRule> CustomRules { get; set; }
    public List<RetargetRule> RetargetRules { get; set; }
    public int? ContainerId { get; set; }
}

public class StaticRules
{
    public decimal? MinPrice { get; set; }
    public decimal? MaxPrice { get; set; }
    public List<string> Brand { get; set; }
    public List<string> Availability { get; set; }
    public List<string> Condition { get; set; }
    public List<string> GoogleProductCategory { get; set; }
    public List<string> ItemId { get; set; }
    public List<object> Items { get; set; }
    public string SelectedRuleType { get; set; } = "Static";
}

public class CustomRule
{
    public Dictionary<string, string> VisitorMatch { get; set; }
    public Dictionary<string, string> TeaserFeedMatch { get; set; }
}
public class RetargetRule
{
    public string VariableName { get; set; }
    public string VariableFeedMatchName { get; set; }
    public bool FeelRndIfNotEnough { get; set; }
    public List<string> RetargetToFeedVariable { get; set; }
}