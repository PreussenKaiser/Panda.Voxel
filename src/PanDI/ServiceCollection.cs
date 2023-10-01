using System.Collections;

namespace PanDI;

public sealed class ServiceCollection : ICollection<ServiceDescriptor>
{
	private readonly List<ServiceDescriptor> descriptors = new();

	public int Count => this.descriptors.Count;

	public bool IsReadOnly => false;

	public void Add(ServiceDescriptor item)
	{
		this.descriptors.Add(item);
	}

	public void Clear()
	{
		this.descriptors.Clear();
	}

	public bool Contains(ServiceDescriptor item)
	{
		bool result = this.descriptors.Contains(item);

		return result;
	}

	public void CopyTo(ServiceDescriptor[] array, int arrayIndex)
	{
		this.descriptors.CopyTo(array, arrayIndex);
	}

	public IEnumerator<ServiceDescriptor> GetEnumerator()
	{
		IEnumerator<ServiceDescriptor> enumerator = this.descriptors.GetEnumerator();

		return enumerator;
	}

	public bool Remove(ServiceDescriptor item)
	{
		bool result = this.descriptors.Remove(item);

		return result;
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		IEnumerator enumerator = this.descriptors.GetEnumerator();

		return enumerator;
	}
}
