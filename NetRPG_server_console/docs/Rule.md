# 서버(TCP chat Server, TCP game Server)
## 작업 규칙
### 1.1 IDE : JetBrains Rider 2024.2.6
- OS : Windows 11, Ubuntu 20.04

### 1.2 형상 관리
- **Git**을 사용하여 소스 코드 버전 관리.
- git Flow 또는 GitHub Flow를 따르며, 브랜치 명명 규칙은 다음과 같음:
  - 메인 : main
  - 기능 개발 : feature/기능명
  - 버그 수정 : bugfix/버그명
  - 릴리즈 : release/버전명
  - 개발 : develop/버전명
### 1.3 패키지 관리
  NuGet 패키지 관리자를 사용하여 외부 라이브러리 관리.
  사용한 패키지는 packages.config 또는 *.csproj 파일에 기록.
### 1.4 테스트
  단위 테스트는 MSTest 또는 NUnit 사용.
  테스트 클래스는 Tests 접미사를 사용하여 명명 (예: MyClassTests).

## 코딩 규칙
### 2.1 네이밍 규칙
- **클래스** : PascalCase (예: MyClass)
- **메서드** : PascalCase (예: CalculateTotal)
- **변수** : camelCase (예: totalAmount)
- **상수** : UPPER_SNAKE_CASE (예: MAX_VALUE)


### 2.2 들여쓰기
 - 백 4칸 사용.
 - 탭 사용 금지.

### 2.3 줄 길이
- 한 줄의 길이는 80자 이하로 유지. 필요한 경우 줄 바꿈.

### 2.4 주석
코드의 의도를 명확히 하기 위해 적절한 주석을 추가.
문서화 주석 사용: /// 형태로 메서드 및 클래스 설명.
### 2.5 오류 처리
예외 처리는 try-catch 블록을 사용하여 적절히 처리.
사용자 정의 예외 클래스 사용 시, Exception 클래스를 상속하여 작성.
### 2.6 코드 구조
각 클래스는 하나의 파일에 작성하며, 파일명은 클래스명과 동일하게 함.
네임스페이스는 주제에 따라 그룹화.

## 3. 코드 리뷰
   모든 코드 변경 사항은 최소 1명의 리뷰어에게 검토받아야 함.
   코드 리뷰는 GitHub Pull Request 기능을 통해 수행.
## 4. 문서화
   프로젝트 문서는 Markdown 형식으로 작성.
   API 문서는 XML 문서화 주석을 활용하여 자동 생성.
