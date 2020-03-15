namespace Misc.InputAdapter {
	public interface IInputAdapter<in Source, out Target> {
		Target GetAdaptedInput(Source userInput);
	}
}