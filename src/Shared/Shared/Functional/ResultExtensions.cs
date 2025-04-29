namespace Shared.Functional;

public static class ResultExtensions
{
    /// <summary>
    /// Matches the success status of the result to the corresponding functions.
    /// </summary>
    /// <typeparam name="T">The result type.</typeparam>
    /// <param name="result">The result.</param>
    /// <param name="onSuccess">The on-success function.</param>
    /// <param name="onFailure">The on-failure function.</param>
    /// <returns>
    /// The result of the on-success function if the result is a success result, otherwise the result of the failure result.
    /// </returns>
    public static T Match<T>(this Result result, Func<T> onSuccess, Func<Error, T> onFailure) => result.IsSuccess ? onSuccess() : onFailure(result.Error);

    /// <summary>
    /// Matches the success status of the result to the corresponding functions.
    /// </summary>
    /// <typeparam name="TIn">The result type.</typeparam>
    /// <typeparam name="TOut">The output result type.</typeparam>
    /// <param name="result">The result.</param>
    /// <param name="onSuccess">The on-success function.</param>
    /// <param name="onFailure">The on-failure function.</param>
    /// <returns>
    /// The result of the on-success function if the result is a success result, otherwise the result of the failure result.
    /// </returns>
    public static TOut Match<TIn, TOut>(
        this Result<TIn> result,
        Func<TIn, TOut> onSuccess,
        Func<Error, TOut> onFailure) => result.IsSuccess ? onSuccess(result.Value) : onFailure(result.Error);

    /// <summary>
    /// Matches the success status of the result to the corresponding functions.
    /// </summary>
    /// <typeparam name="T">The result type.</typeparam>
    /// <param name="resultTask">The result task.</param>
    /// <param name="onSuccess">The on-success function.</param>
    /// <param name="onFailure">The on-failure function.</param>
    /// <returns>
    /// The result of the on-success function if the result is a success result, otherwise the result of the failure result.
    /// </returns>
    public static async Task<T> Match<T>(this Task<Result> resultTask, Func<T> onSuccess, Func<Error, T> onFailure)
    {
        Result result = await resultTask;

        return result.IsSuccess ? onSuccess() : onFailure(result.Error);
    }

    /// <summary>
    /// Matches the success status of the result to the corresponding functions.
    /// </summary>
    /// <typeparam name="TIn">The result type.</typeparam>
    /// <typeparam name="TOut">The output result type.</typeparam>
    /// <param name="resultTask">The result task.</param>
    /// <param name="onSuccess">The on-success function.</param>
    /// <param name="onFailure">The on-failure function.</param>
    /// <returns>
    /// The result of the on-success function if the result is a success result, otherwise the result of the failure result.
    /// </returns>
    public static async Task<TOut> Match<TIn, TOut>(
        this Task<Result<TIn>> resultTask,
        Func<TIn, TOut> onSuccess,
        Func<Error, TOut> onFailure)
    {
        Result<TIn> result = await resultTask;

        return result.IsSuccess ? onSuccess(result.Value) : onFailure(result.Error);
    }
}
