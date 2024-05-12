import os
from PIL import Image
from imaginairy_normal_map.model import create_normal_map_pil_img

script_dir = os.path.dirname(os.path.realpath(__file__))

Txtfile_name = "TxtPath.txt"
Txtfile_path = os.path.join(script_dir, Txtfile_name)

Changed_script_dir = script_dir.replace("\\", "/")

with open(Txtfile_path, 'r') as file:
    lines = file.readlines()
#용호가 갤러리에서 값을 어떻게 넘겨주는지 보고 변경할 것
#imagePath = Changed_script_dir + "/" + lines[0] + ".jpg"
imagePath = "C:/Users/10Group/Documents/GitHub/testest/Assets/Resources/Images/qwe.jpeg"
print(imagePath)
divide = imagePath.split('.')
if not os.path.exists(divide[0] + "_normal." + divide[1]):
    #노말맵이 이미 있으면 안만들고 파이썬 끝나게 수정할것
    img = Image.open(imagePath) #원본
    normal_img = create_normal_map_pil_img(img)
    normal_img.save(divide[0] + "_normal." + divide[1])
    print("excute")