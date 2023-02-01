namespace HostApp.Models;
public class AnswerModel
{
    public AnswerModel()
    {
    }

    public AnswerModel(bool status)
    {
        Status = status;
    }

    public AnswerModel(bool status, object? answer)
    {
        Status = status;
        Answer = answer;
    }

    public AnswerModel(bool status, object? answer, int? error, string? errorMessage)
    {
        Status = status;
        Answer = answer;
        Error = error;
        ErrorMessage = errorMessage;
    }

    public bool Status { get; set; }
    public object? Answer { get; set; }
    public int? Error { get; set; }
    public string? ErrorMessage { get; set; }
}
