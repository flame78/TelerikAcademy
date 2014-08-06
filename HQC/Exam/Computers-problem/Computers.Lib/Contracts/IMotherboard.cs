namespace Computers.Lib.Contracts
{
    /// <summary>
    /// Defines an Motherboard interface.
    /// </summary>
    public interface IMotherboard
    {
        /// <summary>
        /// Read value from memory on the motherboard.
        /// </summary>
        /// <returns>Value stored in the memory on the motherboard.</returns>
        int LoadRamValue();

        /// <summary>
        /// Store value to the memory on the motherboard.
        /// </summary>
        /// <param name="value">Value to be saved in the memory.</param>
        void SaveRamValue(int value);

        /// <summary>
        /// Draw text at the video card installed on motherboard.
        /// </summary>
        /// <param name="text">Text to be displayed on the video card installed on motherboard.</param>
        void DrawOnVideoCard(string text);
    }
}