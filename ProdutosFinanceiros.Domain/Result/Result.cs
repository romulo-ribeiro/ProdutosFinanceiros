using FluentValidation.Results;

namespace ProdutosFinanceiros.Domain.Result
{
    public class Result<TEntity>
    {
        public bool IsValid { get; set; }
        public List<string> Errors { get; set; }
        public TEntity Entity { get; set; }

        public Result()
        {
            IsValid = false;
            Errors = new List<string>();
        }

        public Result(TEntity entity, ValidationResult result)
        {
            IsValid = result.IsValid;
            Entity = entity;
            Errors = [.. result.Errors.Select(q => q.ErrorMessage)];
        }
    }
}
