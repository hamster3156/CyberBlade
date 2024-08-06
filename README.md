# 概要
2023年2月～2023年6月の時期に制作していたゲームで、自身が作成したスクリプトをまとめたリポジトリです。

# 実行ファイルは以下の場所にあります  
https://drive.google.com/drive/folders/1psDiANBRokf86vGYxsoggJJT_T5lbm8_?usp=drive_link

# フォルダーの内容について

| フォルダー名              | 機能の簡単な説明                           |
|---------------------------|--------------------------------------------|
| Animation                 | Animationに関連するクラス                  |
| AnimatorStateMachine      | Animatorのステートで利用したクラス         |
| Common                    | エフェクトを削除するクラス                 |
| Controller                | Animatorステートの遷移管理クラスやInputSystemの入力を管理するクラス |
| Interface                 | ダメージやノックバックなどの処理を行うクラス |
| Manager                   | プレイヤーの攻撃入力を調整するクラスや画面のカメラ揺れなどのクラス |
| Physics                   | プレイヤーの当たり判定に関するクラス       |
| StateMachine              | Animatorステートで管理されていない移動に関する内容のクラス |

# 今回のスクリプトについて  
AnimatorStateMachineを利用してゲーム開発を行いました。
![image](https://github.com/user-attachments/assets/c1cf31a6-0e96-44ec-957a-a2e7ca63c92e)   
Animatorの状態ごとにクラスを用意することによって、クラスの可読性と拡張性を向上させることができました。
![image](https://github.com/user-attachments/assets/98f52df3-36d3-4ed0-a86c-6a1feaebf6ed)

# 今回の制作で工夫した点  
[動画](https://github.com/user-attachments/assets/17972fd9-a9b4-486b-b329-e3c826bcd8c3)のプレイヤーが強力な攻撃を行った時に、画面を揺らす処理やボスストップ演出を作成しました。画面の揺らす処理はCinemachineのNoise機能でランダムな揺れを作成し、スクリプトで揺れの強さを調整できるように作成しました。ボスストップ演出はUnity内のtimeScaleを極端に落とすことで作成し、2つの機能を組み合わせてゲームにおける手ごたえを向上させることができました。


