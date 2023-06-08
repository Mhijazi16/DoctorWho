namespace DoctorWho.Db.Models;

public class ViewEpisode
{
    public int EpisodeId { get; set; }

    public int? AuthorId { get; set; }

    public int? DoctorId { get; set; }

    public string? Title { get; set; }

    public string? AuthorName { get; set; }

    public string? DoctorName { get; set; }

    public int SeriesNumber { get; set; }

    public string? Enemies { get; set; }

    public string? Companions { get; set; }

    public short EpisodeNumber { get; set; }

    public string? EpisodeType { get; set; }

    public DateOnly EpisodeDate { get; set; }

    public string? Notes { get; set; }

    public override string ToString()
    {
        return $"EpisodeId: {EpisodeId}, AuthorId: {AuthorId}, DoctorId: {DoctorId}, Title: {Title}, AuthorName: {AuthorName}, DoctorName: {DoctorName}, " +
               $"SeriesNumber: {SeriesNumber}, Enemies: {Enemies}, Companions: {Companions}, EpisodeNumber: {EpisodeNumber}, " +
               $"EpisodeType: {EpisodeType}, EpisodeDate: {EpisodeDate}, Notes: {Notes}";
    }
}
