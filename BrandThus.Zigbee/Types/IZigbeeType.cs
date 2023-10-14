namespace BrandThus.Zigbee.Types;
	#region Properties
	byte[] data { get; set; }





	#endregion
	#region Create
	static T Create<T>(byte value) where T : IZigbeeType, new() => new T { data = new byte[1] { value } };
	static T Create<T>(int value, int length) where T : IZigbeeType, new() { return Create<T>((long)value, length); }
	static T Create<T>(uint value, int length) where T : IZigbeeType, new() => Create<T>((ulong)value, length);
	static T Create<T>(long value, int length) where T : IZigbeeType, new()
	static T Create<T>(ulong value, int length) where T : IZigbeeType, new()



	#endregion
	#region Read
	void Read(ZigbeeReader reader) => data = reader.ReadBytes(3);
	static T Read<T>(ZigbeeReader read, int length) where T : IZigbeeType, new() => new T { data = read.ReadBytes(length) };
	#endregion

	#region Write
	void Write(ZigbeeWriter writer) => writer.Write(data);
	#endregion
}