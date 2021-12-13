# Quan_Ly_KTX
## QUAN TRỌNG
### NẾU PULL HOẶC CLONE VỀ LUÔN NHỚ VÀO KTX_KMAContext HÀM OnConfigure ĐỔI CONNECTIONSTRING VỀ GIÁ TRỊ CỦA SQLSERVER BỌN MÀY
## Đây là CI/CD để làm việc

  Muốn clone thì:
  ```cmd
  cd <folder muốn đặt project>
  git clone https://github.com/NotAsea/Quan_Ly_KTX.git
  ```
  nó tự clone về luôn nhớ sau khi clone thì chạy cái này
  ```cmd
  dotnet tool install --global dotnet-ef
  dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 6.0.0
  dotnet add package Microsoft.EntityFrameworkCore.Tools --version 6.0.0
  dotnet add package Microsoft.EntityFrameworkCore --version 6.0.0 
  dotnet build
  dotnet ef database scaffold "" Microsoft.EntityFrameworkCore.SqlServer -o Models 
  ```
  Muốn push hay pull về thì:  
 ```cmd
  git init 
  git remote add origin https://github.com/NotAsea/Quan_Ly_KTX.git 
  git fetch --all 
  git pull 
 ```
 
  muốn commit và push   
  ```cmd
  git status #check xem có lm việc tạo orgin của link trên 
  ``` 

  ```cmd
  git add 
  git commit -m <thông điệp không dk để trống> 
  git push -u origin branch 
  ``` 
  nếu m đã push dk một lần vào project lần sau chỉ việc (nhớ là pull trk r hãy push)
  ```cmd
  git add 
  git commit -m <thông điệp> 
  git push 
  ``` 
