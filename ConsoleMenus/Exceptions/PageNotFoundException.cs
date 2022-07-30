using System.Runtime.Serialization;

namespace ConsoleMenus.Exceptions;

[Serializable]
public class PageNotFoundException<TPage> : Exception
{
	public override string Message => $"Page type {typeof(TPage).Name} already exists";
	
	public PageNotFoundException() {}
	
	protected PageNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context){}
}