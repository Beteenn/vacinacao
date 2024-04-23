namespace CartaoVacina.Core.Results;

public readonly struct Result
{
    private readonly string _errorMesage;

    public bool IsSuccess { get; }
    public bool IsError => !IsSuccess;

    public string ErrorMesage => _errorMesage;

    private Result(bool isSuccess)
        => IsSuccess = isSuccess;

    private Result(bool isSuccess, string errorMessage)
        => (IsSuccess, _errorMesage) = (isSuccess, errorMessage);

    public static readonly Result Success = new(true);

    public static Result Fail(string errorMessage)
        => new(false, errorMessage);

    public static implicit operator bool(Result result)
        => result.IsSuccess;
}
