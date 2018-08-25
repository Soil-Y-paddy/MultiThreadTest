using System;
using System.Collections.Generic;
using System.Reflection;

namespace bgwTest
{

	/// <summary>
	///  ユーティリティ
	/// </summary>
	class Utility
	{

		/// <summary>
		/// 指定したインターフェイスを実装している型を取得する 
		/// </summary>
		/// <param name="a_tpIfType">インターフェイスの型( typeof(Interface) )</param>
		/// <returns>指定インターフェイスを実装したクラスの型に対するリスト</returns>
		public static List<Type> GetClassesFromImpl( Type a_tpIfType )
		{
			// 戻り値
			List<Type> lstRetVal = new List<Type>( );


			//現在のコードを実行しているアセンブリを取得する
			Assembly objAsm = Assembly.GetExecutingAssembly( );

			//アセンブリで定義されている型から、
			foreach( Type objTp in objAsm.GetTypes( ) )
			{
				// 指定IFを継承しているクラスを取得する
				// IF自身は除外する
				if( a_tpIfType.IsAssignableFrom( objTp ) && ( a_tpIfType != objTp ) )
				{
					lstRetVal.Add( objTp );
				}

			}

			return lstRetVal;
		}
	}
}
