# invillia
Challenge Invillia

-1) executar rota -> [GET]v1/welcome -> isso vai criar um usuário na base com nome "invillia" e senha "invillia";

-2) Necessário realizar a autenticação:

	- [POST]v1/users/login
	
	(Este token deverá ser diferente desse do exemplo)
	- copiar o token gerado: eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjIiLCJyb2xlIjoiYWRtaW4iLCJuYmYiOjE2MTAzMTQxNTQsImV4cCI6MTYxMDMxNzc1NCwiaWF0IjoxNjEwMzE0MTU0fQ.r_JkAN0p-c2dQv49r6Lfpieu7xjMKNXpbKxPcW85NVo

-3) Inserir alguns jogos:
	
	(Este token deverá ser diferente desse do exemplo)
	- Inserir no header da solicitação o token gerado na autenticação acompanhado do padrão Bearer ->
		Authorization : Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjIiLCJyb2xlIjoiYWRtaW4iLCJuYmYiOjE2MTAzMTQxNTQsImV4cCI6MTYxMDMxNzc1NCwiaWF0IjoxNjEwMzE0MTU0fQ.r_JkAN0p-c2dQv49r6Lfpieu7xjMKNXpbKxPcW85NVo

	- [POST]v1/games
		- {"title": "God of War", "description" : "Jogo RPG"}
		- {"title": "Pes 2021", "description" : "Jogo Futebol"}
		- {"title": "FIFA 2021", "description" : "Jogo Futebol 2"}

-4) Editar algum jogo:
	
	(Este token deverá ser diferente desse do exemplo)
	- Inserir no header da solicitação o token gerado na autenticação acompanhado do padrão Bearer ->
		Authorization : Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjIiLCJyb2xlIjoiYWRtaW4iLCJuYmYiOjE2MTAzMTQxNTQsImV4cCI6MTYxMDMxNzc1NCwiaWF0IjoxNjEwMzE0MTU0fQ.r_JkAN0p-c2dQv49r6Lfpieu7xjMKNXpbKxPcW85NVo
	
	- [PUT]v1/games/{id} (para atualizar algum registro do jogo)
		- {"id": 5, "title": "FIFA 2021", "description" : "Jogo Futebol TOP"}

-5) Ver a lista de jogos:

	(Este token deverá ser diferente desse do exemplo)
	- Inserir no header da solicitação o token gerado na autenticação acompanhado do padrão Bearer ->
		Authorization : Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjIiLCJyb2xlIjoiYWRtaW4iLCJuYmYiOjE2MTAzMTQxNTQsImV4cCI6MTYxMDMxNzc1NCwiaWF0IjoxNjEwMzE0MTU0fQ.r_JkAN0p-c2dQv49r6Lfpieu7xjMKNXpbKxPcW85NVo
	
	- [GET]v1/games/

-6) Para deletar algum jogo:

	(Este token deverá ser diferente desse do exemplo)
	- Inserir no header da solicitação o token gerado na autenticação acompanhado do padrão Bearer ->
		Authorization : Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjIiLCJyb2xlIjoiYWRtaW4iLCJuYmYiOjE2MTAzMTQxNTQsImV4cCI6MTYxMDMxNzc1NCwiaWF0IjoxNjEwMzE0MTU0fQ.r_JkAN0p-c2dQv49r6Lfpieu7xjMKNXpbKxPcW85NVo
	
	- [DELETE]v1/games/{id}

-7) Inserir alguns amigos:

	(Este token deverá ser diferente desse do exemplo)
	- Inserir no header da solicitação o token gerado na autenticação acompanhado do padrão Bearer ->
		Authorization : Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjIiLCJyb2xlIjoiYWRtaW4iLCJuYmYiOjE2MTAzMTQxNTQsImV4cCI6MTYxMDMxNzc1NCwiaWF0IjoxNjEwMzE0MTU0fQ.r_JkAN0p-c2dQv49r6Lfpieu7xjMKNXpbKxPcW85NVo

	- [POST]v1/friends
		- {"name": "Luan Sarmento"}
		- {"Name": "Guilherme"}
		- {"Name": "Samuel"}

-8 ) Editar algum amigo:

	(Este token deverá ser diferente desse do exemplo)
	- Inserir no header da solicitação o token gerado na autenticação acompanhado do padrão Bearer ->
		Authorization : Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjIiLCJyb2xlIjoiYWRtaW4iLCJuYmYiOjE2MTAzMTQxNTQsImV4cCI6MTYxMDMxNzc1NCwiaWF0IjoxNjEwMzE0MTU0fQ.r_JkAN0p-c2dQv49r6Lfpieu7xjMKNXpbKxPcW85NVo
	
	-[PUT]v1/friends/{id}
		- {"id": 6, "name": "Paulete Secretti"}

-9) Deletar algum amigo:
	
	(Este token deverá ser diferente desse do exemplo)
	- Inserir no header da solicitação o token gerado na autenticação acompanhado do padrão Bearer ->
		Authorization : Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjIiLCJyb2xlIjoiYWRtaW4iLCJuYmYiOjE2MTAzMTQxNTQsImV4cCI6MTYxMDMxNzc1NCwiaWF0IjoxNjEwMzE0MTU0fQ.r_JkAN0p-c2dQv49r6Lfpieu7xjMKNXpbKxPcW85NVo

	-[DELETE]v1/friends/{id}

-10) Ver a lista de amigos:
	
	(Este token deverá ser diferente desse do exemplo)
	- Inserir no header da solicitação o token gerado na autenticação acompanhado do padrão Bearer ->
		Authorization : Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjIiLCJyb2xlIjoiYWRtaW4iLCJuYmYiOjE2MTAzMTQxNTQsImV4cCI6MTYxMDMxNzc1NCwiaWF0IjoxNjEwMzE0MTU0fQ.r_JkAN0p-c2dQv49r6Lfpieu7xjMKNXpbKxPcW85NVo
	
	-[GET]v1/friends

-11) Cadastrar a retirada de um jogo:
	
	(Este token deverá ser diferente desse do exemplo)
	- Inserir no header da solicitação o token gerado na autenticação acompanhado do padrão Bearer ->
		Authorization : Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjIiLCJyb2xlIjoiYWRtaW4iLCJuYmYiOjE2MTAzMTQxNTQsImV4cCI6MTYxMDMxNzc1NCwiaWF0IjoxNjEwMzE0MTU0fQ.r_JkAN0p-c2dQv49r6Lfpieu7xjMKNXpbKxPcW85NVo

	-[POST]v1/manager/take-game
		- {"friendId": 7, "gameId": 3}

-12) Devolver um jogo

	(Este token deverá ser diferente desse do exemplo)
	- Inserir no header da solicitação o token gerado na autenticação acompanhado do padrão Bearer ->
		Authorization : Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjIiLCJyb2xlIjoiYWRtaW4iLCJuYmYiOjE2MTAzMTQxNTQsImV4cCI6MTYxMDMxNzc1NCwiaWF0IjoxNjEwMzE0MTU0fQ.r_JkAN0p-c2dQv49r6Lfpieu7xjMKNXpbKxPcW85NVo

	-[PUT]v1/manager/receive-game/{id}

-13) Deletar um jogo

	(Este token deverá ser diferente desse do exemplo)
	- Inserir no header da solicitação o token gerado na autenticação acompanhado do padrão Bearer ->
		Authorization : Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjIiLCJyb2xlIjoiYWRtaW4iLCJuYmYiOjE2MTAzMTQxNTQsImV4cCI6MTYxMDMxNzc1NCwiaWF0IjoxNjEwMzE0MTU0fQ.r_JkAN0p-c2dQv49r6Lfpieu7xjMKNXpbKxPcW85NVo
	
	-[DELETE]/v1/manager/{id}

-14) Visualizar todos empréstimos do Jogo

	(Este token deverá ser diferente desse do exemplo)
	- Inserir no header da solicitação o token gerado na autenticação acompanhado do padrão Bearer ->
		Authorization : Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjIiLCJyb2xlIjoiYWRtaW4iLCJuYmYiOjE2MTAzMTQxNTQsImV4cCI6MTYxMDMxNzc1NCwiaWF0IjoxNjEwMzE0MTU0fQ.r_JkAN0p-c2dQv49r6Lfpieu7xjMKNXpbKxPcW85NVo

	-[GET]/v1/manager

- Notas de regras de negócio.

	- Não será permitido emprestar um jogo que ainda não foi devolvido
	- Todos registros estão separados por UserId, é possível que mais que um usuário utilize da API sem conflito de dados.
	
- A documentação gerada pelo swagger está disponível eim

	- [HOST]/swagger/index.html
