const USERS_PER_PAGE = 20;
let currentPage = 1;
let allUsers = [];

$(document).ready(function() {
    fetchUsers(currentPage);

    function fetchUsers(page) {
        $.ajax({
            url: `https://api.github.com/users?since=${(page - 1) * USERS_PER_PAGE}`,
            method: 'GET',
            success: function(data) {
                allUsers = data;
                renderPage(currentPage);
                renderPagination();
            },
            error: function() {
                alert('Failed to fetch users.');
            }
        });
    }

    function renderPage(page) {
        const start = (page - 1) * USERS_PER_PAGE;
        const end = start + USERS_PER_PAGE;
        const usersToRender = allUsers.slice(start, end);
        renderUsers(usersToRender);
    }

    function renderUsers(users) {
        $('#user-cards').empty();
        users.forEach(user => {
            $('#user-cards').append(`
                <div>
                    <img src="${user.avatar_url}" alt="${user.login}" class="rounded-top-2 img">
                    <div class="px-3 py-4 bg-white border rounded-bottom-2">
                        <h5>${user.login}</h5>
                        <button class="button w-100 mt-4 bg-primary rounded-1 py-1 text-center"><a class="text-white text-decoration-none" href="${user.html_url}" target="_blank">View profile</a></button> 
                    </div>
                </div>
            `);
        });
    }

    function renderPagination() {
        const totalPages = Math.ceil(allUsers.length / USERS_PER_PAGE);
        $('#pagination').empty();

        for (let i = 1; i <= totalPages; i++) {
            if (i === 1) {
                $('#pagination').append(`
                    <li class="page-item ${currentPage === 1 ? 'disabled' : ''}">
                        <p class="page-link pointer" data-page="${currentPage - 1}" style="&">Previous</p>
                    </li>
                `);
            }
            $('#pagination').append(`
                <li class="page-item ${i === currentPage ? 'active' : ''}">
                    <p class="page-link pointer" data-page="${i}">${i}</p>
                </li>
            `);
            if (i === totalPages) {
                $('#pagination').append(`
                    <li class="page-item ${currentPage === totalPages ? 'disabled' : ''}">
                        <p class="page-link pointer" data-page="${currentPage + 1}">Next</p>
                    </li>
                `);
            }
        }

        $('.page-link').click(function(e) {
            e.preventDefault();
            currentPage = $(this).data('page');
            fetchUsers(currentPage);
        });
    }
});
