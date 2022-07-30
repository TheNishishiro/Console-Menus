using System.Runtime.Serialization;

namespace ConsoleMenus.Exceptions;

[Serializable]
public class PageTypeExistsException<TPage> : Exception
{
	public override string Message => $"Given page {typeof(TPage).Name} does not exist.";
	public PageTypeExistsException()
	{
	}
	protected PageTypeExistsException(SerializationInfo info, StreamingContext context) : base(info, context){}
}