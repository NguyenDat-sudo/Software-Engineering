function initializeFlatpickr(selector) {
    let temp = null;
    flatpickr(selector, {
        dateFormat: "d/m/Y",
        allowInput: false,
        static: true, // Keep calendar anchored to input
        onChange: function (selectedDates, dateStr, instance) {
            // Keep the calendar open on day selection
            temp = dateStr;
            instance.isOpen = true;
        },
        onReady: function (selectedDates, dateStr, instance) {
            const calendarContainer = instance.calendarContainer;

            // Add buttons only once
            if (!calendarContainer.querySelector('.custom-buttons')) {
                const buttonContainer = document.createElement('div');
                buttonContainer.classList.add('custom-buttons', 'mt-2', 'd-flex', 'justify-content-start', 'mb-2');

                buttonContainer.innerHTML = `
        <button class="btn btn-sm btn-secondary" type="button" data-clear style="background-color:#ECE6F0;color: #65558F;border-width:0px; margin-right: 140px; margin-left: 6px; font-weight:550;">Clear</button>
        <button class="btn btn-sm btn-warning me-2" type="button" data-cancel style="background-color:#ECE6F0;color: #65558F; border-width:0; font-weight:550;">Cancel</button>
        <button class="btn btn-sm btn-primary" type="button" data-ok style="background-color:#ECE6F0; color: #65558F; border-width:0;font-weight:550;" >OK</button>
                                        `;

                calendarContainer.appendChild(buttonContainer);

                // Add button functionality
                buttonContainer.querySelector('[data-clear]').addEventListener('click', function () {
                    temp = null;
                    instance.clear();
                });

                buttonContainer.querySelector('[data-cancel]').addEventListener('click', function () {
                    temp = null;
                    instance.clear();
                    instance.close();
                });

                buttonContainer.querySelector('[data-ok]').addEventListener('click', function () {
                    if (temp) {
                        instance.setDate = temp;
                    }
                    instance.close();
                });
            }
        }
    });
}

// Initialize Flatpickr for inputs
initializeFlatpickr("#start-date");
initializeFlatpickr("#end-date");

