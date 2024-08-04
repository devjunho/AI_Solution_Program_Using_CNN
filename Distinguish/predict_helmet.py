import numpy as np
from tensorflow import keras
from PIL import Image
import matplotlib.pyplot as plt

# 저장된 모델을 로드합니다.
model = keras.models.load_model('jgb-model.keras')

def preprocess_image(img_path):
    """이미지를 로드하고 전처리하는 함수입니다."""
    img = Image.open(img_path).convert('RGB')  # RGB 형식으로 변환
    img = img.resize((150, 150))  # 모델에 맞게 이미지 크기 조정
    img_array = np.asarray(img) / 255.0  # 0과 1 사이로 정규화
    img_array = np.expand_dims(img_array, axis=0)  # 배치 차원 추가
    return img_array

def predict_helmet(img_path):
    """이미지 경로를 입력받아 헬멧 여부를 예측합니다."""
    img_array = preprocess_image(img_path)
    prediction = model.predict(img_array)
    print("Prediction: ", prediction)
    if prediction[0] > 0.8:
        return "Helmet"
    else:
        return "No Helmet"

# 테스트할 이미지 경로
image_path = "C:/Users/LMS/PycharmProjects/pythonProject/test/junho.jpg"

# 예측 수행
result = predict_helmet(image_path)
print(f"The image is classified as: {result}")

# 이미지 시각화
img = Image.open(image_path)
plt.imshow(img)
plt.title(f"Prediction: {result}")
plt.axis('off')
plt.show()
