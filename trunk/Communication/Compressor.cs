/*
PoL - The polyhedral card game simulator
Copyright (C) 2011 Andrea Biagini

This program is free software; you can redistribute it and/or
modify it under the terms of the GNU General Public License
as published by the Free Software Foundation; either version 2
of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program; if not, write to the Free Software
Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
*/

using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Zip = ICSharpCode.SharpZipLib.Zip.Compression;

namespace Communication
{
	class Compressor
	{
		static public byte[] Compress(byte[] bytes)
		{
			MemoryStream memory = new MemoryStream();
			using(Zip.Streams.DeflaterOutputStream stream = new Zip.Streams.DeflaterOutputStream(memory, new Zip.Deflater()))
				stream.Write(bytes, 0, bytes.Length);
			return memory.ToArray();
		}

		static public byte[] Decompress(byte[] bytes)
		{
			MemoryStream memory = new MemoryStream();
			using(Zip.Streams.InflaterInputStream stream = new Zip.Streams.InflaterInputStream(new MemoryStream(bytes)))
			{
				byte[] writeData = new byte[4096];
				int size = 1;
				while(size > 0)
				{
					size = stream.Read(writeData, 0, writeData.Length);
					if(size > 0)
						memory.Write(writeData, 0, size);
				}
			}
			return memory.ToArray();
		}
	}
}
