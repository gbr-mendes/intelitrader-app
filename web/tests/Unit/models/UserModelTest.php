<?php

namespace Web\models;

use Web\exceptions\ValidationException;
use Web\models\User;
use PHPUnit\Framework\TestCase;

class UserModelTest extends TestCase
{
    private $userInfo = [
        'id' => 'id',
        'name' => '',
        'surName' => 'Doe',
        'age' => 30
    ];

    public function test_add_user_without_name_fail()
    {
        // Tests that ValidationException is thrown when name is not passed
        $this->expectException(ValidationException::class);
        new User($this->userInfo);
    }

    public function test_add_user_age_less_than_one_fail()
    {
        // Tests that ValidationException is thrown whe age is less than one
        $this->expectException(ValidationException::class);

        $userInfo['name'] = 'Jhon';
        $userInfo['age'] = 0;
        new User($this->userInfo);
    }
}
