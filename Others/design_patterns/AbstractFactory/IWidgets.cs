
namespace AbstractFactory
{
    // 1. DEFINE ABSTRACT PRODUCTS
    // ----------------------------------------------------------------

    /// <summary>
    /// Abstract product for Button
    /// </summary>
    public interface IButton
    {
        public void Paint();
    }

    /// <summary>
    /// Abstract product for CheckBox
    /// </summary>
    public interface ICheckBox
    {
        public void Paint();
    }
}
