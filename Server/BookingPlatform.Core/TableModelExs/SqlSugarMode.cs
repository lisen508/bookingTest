namespace BookingPlatform.Core.TableModelExs
{
    /// <summary>
    /// 批量操作类
    /// </summary>
    public class SqlSugarMode<T> where T : class
    {
        /// <summary>
        /// 操作类型
        /// </summary>
        public string OperationMode { get; set; }
        /// <summary>
        /// 需要操作的实体
        /// </summary>
        public T Entity { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="op"></param>
        public SqlSugarMode(T entity, string op)
        {
            Entity = entity;
            OperationMode = op;
        }
        ///
        public SqlSugarMode()
        {

        }
    }
}
