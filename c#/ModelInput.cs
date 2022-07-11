using Microsoft.ML.Data;

namespace godot_net_server
{
    /// <summary>
    /// Model of input for neuron model
    /// Convenient way of understanding how you should describe it here:
    /// https://netron.app
    /// </summary>
    public class ModelInput
    {
        // Shows that expected input format is 28 arrays of 28 arrays of 1 element in py,
        // though in c# it asks for an array of 28*28*1=784 elements
        [VectorType(28, 28, 1)] 
        // Column name for input
        [ColumnName("conv2d_1_input")]
        public float[] Input { get; set; }
    }
}