<?php
$users = $api_service->get_users();

?>
<div class="d-flex flex-column justify-content-center align-items-center p-3">
    <h1>Users List</h1>
    <div class="user-list col-4 p-4">
        <?php foreach ($users as $user) : ?>
            <div class="user d-flex justify-content-between align-items-center p-2">
                <h6><?php echo "{$user->name} {$user->surName}"; ?></h6>
                <div class="user-actions">
                    <a href="<?php echo "?page=add_update_user&user_id={$user->id}" ?>"><i class="fa-solid fa-pen-to-square fa-lg"></i></a>
                    <i class="fa-solid fa-trash fa-lg"></i>
                </div>
            </div>
        <?php endforeach; ?>
    </div>
</div>