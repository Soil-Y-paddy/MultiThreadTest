# MultiThreadTest
.netでマルチスレッドを実装するテスト

## マルチスレッド
ウィンドウズアプリで、ある重い処理を実行するとき、画面が止まるように見える<be>
これを解決するために、フォームを動かすスレッドとは別に重い処理を実行するスレッドを別にすることが考えられる。<br>

ところで、.NET Framework は、バージョンの改定とともに様々な非同期処理手法が提供されている

+ `Thread`クラス 及び `BeginInvoke` (.NET Framework  Ver1.x以降)
+ `BackgroundWorker` コントロール (.NET Framework  Ver2.x以降)
+ `Task` クラス (.NET Framework  Ver4.x以降)

本リポジトリは、これら複数のマルチスレッドの実装方法を比較したコードサンプルを提供する。<br>
実装は、BackgroundWorkerを用いた手法をベースに比較できるようにした。
そのため、それぞれの手法において提供したサンプルより最適なコーディングが存在することを留意されたい。

 
## マルチスレッド実装クラス
### `ThreadExecuter`  (TestProc\ThreadExecuter.cs)
 .NET Framework  Ver1.x以降 で使用できる `Thread`クラスを用いた手法。<br>
<b> 現状の新規使用は推奨されていない。</b>

### `InvokeExecuter` (TestProc\InvokeExecuter.cs)
 .NET Framework  Ver1.x以降 で使用できる `BeginInvoke`を用いた手法。<br>
<b> 現状の新規使用は推奨されていない。</b>

### `BackGroundExecute` (TestProc\InvokeExecuter.cs)
 .NET Framework  Ver2.x以降 で使用できる `BackgroundWorker`を用いた手法。

### `TaskExecute` (TestProc\TaskExecute.cs)
.NET Framework  Ver4.x以降 で使用できる `Task`を用いた手法。

## インターフェイス
### `IMultiThreadTest` (TestProc\IMultiThreadTest.cs)
 複数のマルチスレッドプログラミングの実装を共通で呼び出すためのインターフェイス

## その他のクラス
### `ThreadTestConst`  (TestProc\IMultiThreadTest.cs)
 テスト用の定数
### `Utility` (Utility.cs)
  ユーティリティ関数
- `public static List< Type> GetClassesFromImpl(Type a_tpIfType)`
  - 指定したインターフェイスを実装している型を取得する 
  
## 画面説明
- テストモード[コンボボックス]　：　テストしたいそれぞれの実装手法を選択する。
- 生成スレッド数[数値入力]　：　バックグラウンドで実行する処理の数
- スレッド内のループ回数[数値入力]：　バックグラウンドで実行する処理のループ回数
- 実行[ボタン] :  押すと、実行開始、 「停止」表示のときは、押すと途中でキャンセルされる。
- 青い部分  ：　実行中、プログレスバーが表示され、それぞれのスレッドの進捗状況が示される。
