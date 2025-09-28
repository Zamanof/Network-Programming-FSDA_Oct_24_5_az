#include<stdio.h>
#include <WinSock2.h>

#pragma comment(lib, "Ws2_32.lib")

#define PORT 27001
#define BUF_SIZE 1024

int main(){
	WSADATA wsadata;
	WSAStartup(MAKEWORD(2, 2), &wsadata);

	SOCKET listener = socket(AF_INET, SOCK_DGRAM, IPPROTO_UDP);
	struct sockaddr_in recv_addr;

	recv_addr.sin_family = AF_INET;
	recv_addr.sin_port = htons(PORT);
	recv_addr.sin_addr.s_addr = htonl(INADDR_ANY);

	bind(listener, (SOCKADDR*)&recv_addr, sizeof(recv_addr));
	char buff[BUF_SIZE];

	struct sockaddr_in sender_addr;

	int sender_addr_size = sizeof(sender_addr);

	while (TRUE)
	{
		int length = recvfrom(listener, buff, BUF_SIZE, 0,
			(SOCKADDR*)&sender_addr, &sender_addr_size);
		buff[length] = '\0';
		if (strcmp(buff, "exit") == 0)
		{
			printf("Goodbye");
			break;
		}
		printf("%s", buff, 7);
	}
	closesocket(listener);
	WSACleanup();
	return 0;
}