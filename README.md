# CyberBlade

2年生の後期から3年生の前期に作成した3Dアクションゲームです。  

- 制作人数  
3人  

- 担当箇所  
プレイヤー操作の開発を行いました。  

- 実行ファイルは以下の場所にあります  
https://drive.google.com/drive/folders/1psDiANBRokf86vGYxsoggJJT_T5lbm8_?usp=drive_link

- フォルダーの内容について  
AnimationフォルダーにはAnimationに関連するクラス  
AnimatorStateMachineフォルダーにはAnimatorのステートで利用したクラス  
Commonフォルダーにはエフェクトを削除するクラス  
ControllerフォルダーにはAnimatorステートの遷移管理クラスやInputSystemの入力を管理するクラス  
Interfaceフォルダーにはダメージやノックバックなどの処理を行うクラス  
Managerフォルダーにはプレイヤーの攻撃入力を調整するクラスや画面のカメラ揺れなどのクラス  
Physicsフォルダーにはプレイヤーの当たり判定関するクラス  
StateMachineフォルダーにはAnimatorステートで管理されていない移動に関する内容のクラス  


- 今回のスクリプトについて  
AnimatorStateMachineを利用してゲーム開発を行いました。
![image](https://github.com/user-attachments/assets/c1cf31a6-0e96-44ec-957a-a2e7ca63c92e)   
Animatorの状態ごとにクラスを用意することによって、クラスの可読性と拡張性を向上させることができました。
![image](https://github.com/user-attachments/assets/98f52df3-36d3-4ed0-a86c-6a1feaebf6ed)

- 今回の制作で工夫した点  
[動画](https://github.com/user-attachments/assets/17972fd9-a9b4-486b-b329-e3c826bcd8c3)のプレイヤーが強力な攻撃を行った時に、画面を揺らす処理やボスストップ演出を作成しました。画面の揺らす処理はCinemachineのNoise機能でランダムな揺れを作成し、スクリプトで揺れの強さを調整できるように作成しました。ボスストップ演出はUnity内のtimeScaleを極端に落とすことで作成し、2つの機能を組み合わせてゲームにおける手ごたえ部分や見栄えを向上させることができました。


