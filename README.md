# TextureImportDemo
テクスチャをインポートする際に、圧縮フォーマットを設定するdemo
### unityバージョン
2019.4.23f1
### demo内容
テクスチャを指定のフォルダにおくと、指定した圧縮フォーマットに自動的に設定される
### 内容詳細
<img width="479" alt="スクリーンショット 2022-03-24 17 20 01" src="https://user-images.githubusercontent.com/59904787/159872896-473d8a3c-ae63-45c6-a2e7-a881380138a9.png">
InAtlasフォルダに入れると、テクスチャを無圧縮に設定
NoInAtlasフォルダに入れると、ASTC_6x6圧縮フォーマットに設定

上記の自動的にフォーマット設定するのは、スクリプトで指定する
<img width="927" alt="スクリーンショット 2022-03-24 17 22 17" src="https://user-images.githubusercontent.com/59904787/159873278-131998d7-aead-49d6-8bcf-9cbfb63f53de.png">
