# SimpleUIFramework
## 注意：该框架并非本人原创，而是整合了看过的几个比较好的框架方法外加自己的一些理解优化。

### 使用与效果预览：

将文件下载到Unity项目的Assets文件夹下，打开Resources/Scenes/DemoScene.unity后运行即可查看效果。

点击按钮前：

![image](https://github.com/user-attachments/assets/adeae403-ce70-4343-962a-81a5bed4311d)


点击后：

![image](https://github.com/user-attachments/assets/faf0f35d-d444-42f5-bc29-2ecc3c932106)



### 注意事项

1.如果需要使用这套框架，只需要在场景中创建一个空物体并且挂载GameRoot脚本，保证场景中存在一个名为Canvas的画布（也可以自己命名，需要在Scripts/UI/UIFrameWork/Manager/UIManager.cs中更改脚本将查找的画布父物体）。

2.UI组件请封装为一个个Panel后做成Prefab，需要用到的UI元素都作为子物体挂载至Panel。每一个Scene和Panel都有其对应的脚本，脚本应继承自SceneBase或BasePanel，Panel脚本无需挂载到Panel物体上，但需要挂载名为UIContainer的组件至Panel物体上。
3.在UIContainer中修改完毕后务必点击Save按钮，才能保存修改至Prefab。

4.需在脚本内定义好其对应的Prefab资源路径所在，通过new脚本类的方式框架会自动创建必要的物体。可以日后自己拓展重写资源加载的方式，框架使用的是Resources.Load方法。



### Panel中重要方法的使用

#### UIContainer

**客制化组件，请挂载到Panel父物体上。以字典的形式保存Panel下可能用到的UI组件，方便在Panel类中获取并进行操作。**

![image](https://github.com/user-attachments/assets/bf9c973d-beba-4962-8a40-2f4f013efe42)


点击Add添加新的UI组件，从左到右分别为：

1.在panel中进行获取时使用的名字，若不进行自定义更改则在拖动物体进物品定义区域时时自动赋值为物体名字

2.拖动要用到的UI组件物体到该区域

3.下拉框UI组件的类型，获取时在相关方法中传入泛型可直接获取到组件，无需再通过物体transform中的GetComponent<>()方法进行获取。
可以进入UIContainer中自己添加新的UI组件的类型及其获取，可以参考已有组件的方法。


#### Panel类的使用

继承了BasePanel的Panel类中持有Panel物体以及其上挂载的UIContainer，使用BasePanel中的方法GetXXX<>()，传入期望获取到的UI组件类型和组件名即可直接获取到组件。之后可以用AddListener等方法为组件添加事件。推荐使用该方法获取以及操作组件，获取更加高效且无需手动在编辑器中为组件添加方法。

**不推荐的方法：**框架中保留早期方法UITool.GetOrAddComponentInChildren<>()，该方法传入期望组件类型、组件名和panel父物体也可获取到UI组件，且无需在UIContainer中实现进行赋值操作。方法本质上是使用遍历方法查找panel下符合条件的子物体，性能较差。使用该方法可以不在panel上挂载UIContainer，但这样做会因为脚本中无法获取到panel上的UIContainer类而报错，需要自己完成解决方案。

