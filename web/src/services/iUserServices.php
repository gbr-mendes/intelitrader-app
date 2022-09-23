<?php

namespace Web\services;

use Web\models\User;

interface iUserServices
{
    public function get_users(): array;
    public function get_user_by_id($user_id): User;
    public function add_user(User $user): bool;
    public function update_user(User $user): bool;
    public function delete_user($user_id): bool;
}
