export const Contact = () => (
<section class="contact_section layout_padding-top">
    <div class="container-fluid">
        <div class="row">
            <div class=" col-md-6">
                <div id="map" class="h-100 w-100 ">
                </div>
            </div>
            <div class=" col-md-6 contact_form-container">
                <div class="contact_box">
                    <form action="">
                        <input type="text" placeholder="Your Name" />
                        <input type="email" placeholder="Email" />
                        <input type="text" placeholder="Phone Number" />
                        <input type="text" placeholder="Message" />
                        <div>
                            <button type="submit">
                                Submit
                            </button>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
</section>);