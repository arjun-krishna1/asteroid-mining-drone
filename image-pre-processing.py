# %%
import numpy as np
import cv2 as cv
import pandas as pd
# %%
img_red = cv.imread('data/frame100-(41.8, 62.7, 25.9).png')
img_blue = cv.imread('data/frame200-(26.8, 150.2, 82.7).png')

# %%
def show_img_list(img_list):
    for i in range(len(img_list)):
        cv.imshow(str(i), img_list[i])
    cv.waitKey(0)
    cv.destroyAllWindows()

# %%
def apply_filter(img):
    lower = np.array([0,50, 50])
    upper = np.array([130,255,255])
    hsv = cv.cvtColor(img, cv.COLOR_BGR2HSV)
    mask = cv.inRange(hsv, lower, upper)
    return cv.bitwise_and(img, img, mask= mask)

# %%
def get_circles(img):
    print()
    gray = cv.cvtColor(img,cv.COLOR_BGR2GRAY)
    gray = cv.medianBlur(img,5)
    circles = cv.HoughCircles(gray,cv.HOUGH_GRADIENT,1,20,
                            param1=50,param2=30,minRadius=0,maxRadius=0)
    return np.uint16(np.around(circles))

# %%
show_img_list([img_red_filter])

# %%
img_red_filter = apply_filter(img_red)

# %%
img_red_fin = img_red_filter[np.any(img_red_filter != 0, axis=2)]

# %%
img_red_fin.shape

# %%
img_red_filter.shape

# %%
img_red_gray = cv.cvtColor(img_red_filter, cv.COLOR_BGR2GRAY)
show_img_list([img_red_gray])
non_zero_idx = np.nonzero(img_red_gray > 10)

# %%
import pandas as pd

# %%
df = pd.DataFrame(non_zero_idx)

# %%
df.head()

# %%
# unq_rows = np.unique(non_zero_idx[0]) 
# if unq_rows[-1] <= (unq_rows[0] + len(unq_rows))*1.1:
#     print (unq_rows[0], unq_rows[-1])

# else:
i = 0
while i < len(unq_rows):
    print(unq_rows[i])
    while i + 1< len(unq_rows) and unq_rows[i+1] < unq_rows[i] + 10:
        i += 1
    i += 1
    print(unq_rows[i - 1])
            

# %%



