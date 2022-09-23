<?php

namespace Web\services;

use PHPUnit\Framework\TestCase;
use Web\models\User;
use stdClass;

class UserServicesTest extends TestCase
{
    private $userInfo = [
        'id' => 'id',
        'name' => 'John',
        'surName' => 'Doe',
        'age' => 30
    ];

    public function test_get_users_returns_array(): void
    {
        $apiServiceMock = $this->createMock(Api_service::class);
        $apiServiceMock->method('call_api')->willReturn(json_encode([]));

        $users_service = new UserServices($apiServiceMock);
        $users = $users_service->get_users();
        $this->assertIsArray($users);
    }

    public function test_get_user_by_id_return_user_instance(): void
    {
        $apiServiceMock = $this->createMock(Api_service::class);
        $users_service = new UserServices($apiServiceMock);

        $userInfo = new stdClass;
        $userInfo->name = 'Jhon';
        $userInfo->surName = 'Doe';
        $userInfo->age = 30;
        $userInfo->id = 'id';

        $apiServiceMock->method('call_api')->willReturn(json_encode($userInfo));
        $user = $users_service->get_user_by_id('id');
        $this->assertInstanceOf(User::class, $user);
    }

    public function test_add_user_success_returns_true(): void
    {
        $apiServiceMock = $this->createMock(Api_service::class);
        $users_service = new UserServices($apiServiceMock);

        $api_response = new stdClass;
        $api_response->statusCode = 201;
        $apiServiceMock->method('call_api')->willReturn(json_encode($api_response));
        $user = new User($this->userInfo);
        $created = $users_service->add_user($user);

        $this->assertTrue($created);
    }

    public function test_add_user_faile_returns_fase(): void
    {
        $apiServiceMock = $this->createMock(Api_service::class);
        $users_service = new UserServices($apiServiceMock);

        $api_response = new stdClass;
        $api_response->statusCode = 400;
        $apiServiceMock->method('call_api')->willReturn(json_encode($api_response));
        $user = new User($this->userInfo);
        $created = $users_service->add_user($user);

        $this->assertFalse($created);
    }

    public function test_update_user_success_returns_true(): void
    {
        $apiServiceMock = $this->createMock(Api_service::class);
        $users_service = new UserServices($apiServiceMock);

        $api_response = new stdClass;
        $api_response->name = 'John';
        $apiServiceMock->method('call_api')->willReturn(json_encode($api_response));
        $user = new User($this->userInfo);
        $updated = $users_service->update_user($user);

        $this->assertTrue($updated);
    }

    public function test_update_user_faile_returns_false(): void
    {
        $apiServiceMock = $this->createMock(Api_service::class);
        $users_service = new UserServices($apiServiceMock);

        $api_response = new stdClass;
        $apiServiceMock->method('call_api')->willReturn(json_encode($api_response));
        $user = new User($this->userInfo);
        $updated = $users_service->update_user($user);

        $this->assertFalse($updated);
    }

    public function test_delete_user_success_returns_true(): void
    {
        $apiServiceMock = $this->createMock(Api_service::class);
        $users_service = new UserServices($apiServiceMock);

        $api_response = new stdClass;
        $api_response->statusCode = 200;
        $apiServiceMock->method('call_api')->willReturn(json_encode($api_response));
        $deleted = $users_service->delete_user('id');

        $this->assertTrue($deleted);
    }

    public function test_delete_user_faile_returns_false(): void
    {
        $apiServiceMock = $this->createMock(Api_service::class);
        $users_service = new UserServices($apiServiceMock);

        $api_response = new stdClass;
        $api_response->statusCode = 400;
        $apiServiceMock->method('call_api')->willReturn(json_encode($api_response));
        $deleted = $users_service->delete_user('id');

        $this->assertFalse($deleted);
    }
}
